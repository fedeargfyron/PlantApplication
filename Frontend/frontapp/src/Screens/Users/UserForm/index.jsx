import React, { useState, useEffect } from "react";
import {Tabs, Tab, Card, CardBody, Input, Button, CheckboxGroup, Checkbox, CircularProgress} from "@nextui-org/react";
import { useForm } from 'react-hook-form'
import { useGroupStore } from '../../../Store/groupsStore.jsx'
import { useUserStore } from '../../../Store/usersStore.jsx'
import { useNavigate, useParams } from 'react-router-dom'
import InformationModal from "../../../Components/InformationModal/index.jsx";

export default function UserForm() {
    const [editForm, setEditForm] = useState(false);
    const [open, setOpen] = useState(false);
    const { 
        register, 
        setValue, 
        handleSubmit, 
        formState: { errors } 
    } = useForm();
    const [groupsSelected, setGroupsSelected] = useState([]);
    const navigate = useNavigate();
    const params = useParams();
    const id = params.id;

    let {
        user, 
        userIsError, 
        userIsLoading,
        fetchUserById,
        addUser,
        addUserIsError, 
        addUserIsLoading,
        updateUser,
        updateUserIsError, 
        updateUserIsLoading,
    } = useUserStore(state => state);

    const fetchGroups = useGroupStore((state) => state.fetchGroups);
    let groups = useGroupStore(state => state.groups);

    useEffect(() => {
      fetchGroups();
    }, [fetchGroups])

    useEffect(() => {
        if(userIsLoading || userIsError)
            return setOpen(true)
    
        setOpen(false)
      }, [userIsLoading, userIsError])

    useEffect(() => {
    if(addUserIsLoading || addUserIsError)
        return setOpen(true)

        setOpen(false)
    }, [addUserIsLoading, addUserIsError])

    useEffect(() => {
        if(updateUserIsLoading || updateUserIsError)
            return setOpen(true)
    
            setOpen(false)
    }, [updateUserIsLoading, updateUserIsError])

    useEffect(() => {
        if (id) fetchUserById(id);
    }, [id, fetchUserById]);

    useEffect(() => {
        if(!user)
            return;

        if(!id)
            return;

        setValue("username", user.username);
        setValue("email", user.email);
        setValue("location", user.location);
        setGroupsSelected(user.groupsIds);
        setEditForm(true);
    }, [user, id, setValue, setEditForm]);

    const onSubmit = async (e) => {
        let body = {
            username: e.username,
            email: e.email,
            location: e.location,
            groupsIds: groupsSelected,
        }

        if(editForm){
            updateUser(body, id, navigate);
            return;
        }

        addUser(body, navigate);
    }

    return (
        <div className="container mx-auto pt-10">
            <InformationModal open={open} setOpen={setOpen} title='User'>
                {(userIsLoading || addUserIsLoading || updateUserIsLoading) && <CircularProgress />}
                {(userIsError || addUserIsError || updateUserIsError) && <p>Error!</p>}
            </InformationModal>
            <form className="flex flex-col max-w-2xl mx-auto" onSubmit={handleSubmit(onSubmit)}>
                <Tabs aria-label="Options" className="max-w-2xl">
                    <Tab key="user" title="User">
                        <Card>
                            <CardBody>
                                <Input label="Username" placeholder="username" className="pb-3" color = {errors.username ? 'danger' : ''} {...register("username", { required: true })}/>
                                <Input label="Email" placeholder="email123@gmail.com" className="pb-3" color = {errors.email ? 'danger' : ''} disabled={editForm}  {...register("email", { required: true })}/>
                                <Input label="Location" placeholder="rosario" className="pb-3" color= {errors.location ? 'danger' : ''} {...register("location", { required: true })}/>
                            </CardBody>
                        </Card>
                    </Tab>
                    <Tab key="groups" title="Groups">
                        <Card>
                            <CardBody>
                                <CheckboxGroup
                                    onChange={setGroupsSelected}
                                    label="Select groups"
                                    defaultValue={groupsSelected}
                                    >
                                    {groups && groups.map(group => 
                                    <Checkbox
                                        value={group.id}
                                        key={group.id}
                                        color="success"
                                        className="text-white"
                                    >
                                        {group.name}
                                    </Checkbox>)}
                                </CheckboxGroup>
                            </CardBody>
                        </Card>  
                    </Tab>
                </Tabs>

                <div className="flex justify-start">
                    <Button className="m-1 bg-green text-white" type="submit">
                        Save
                    </Button>
                    <Button className="m-1" onClick={() => navigate('/users')} color="danger" variant="flat">
                        Cancel
                    </Button>
                </div>
            </form>  
        </div>
    );
}
