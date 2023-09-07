import React, { useState, useEffect } from "react";
import {Tabs, Tab, Card, CardBody, Input, Button, CheckboxGroup, Checkbox} from "@nextui-org/react";
import { useForm } from 'react-hook-form'
import { useGroupStore } from '../../../Store/groupsStore.jsx'
import { useUserStore } from '../../../Store/usersStore.jsx'
import { useNavigate, useParams } from 'react-router-dom'
import { GetToken } from '../../../Components/Helpers/TokenHelper.jsx';

import axios from 'axios'

export default function UserForm() {
    const [editForm, setEditForm] = useState(false);
    const { register, setValue, handleSubmit } = useForm();
    const [groupsSelected, setGroupsSelected] = useState([]);
    const navigate = useNavigate();
    const params = useParams();
    const id = params.id;

    const fetchUserById = useUserStore((state) => state.fetchUserById);
    let user = useUserStore(state => state.user);

    const fetchGroups = useGroupStore((state) => state.fetchGroups);
    let groups = useGroupStore(state => state.groups);

    useEffect(() => {
      fetchGroups();
    }, [fetchGroups])

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

    const getRequestMethod = (body) => editForm ? axios.put(`https://localhost:44374/users/${id}`, body,{
        headers: {
          Authorization: GetToken()
        }
      }) : axios.post('https://localhost:44374/users', body, {
        headers: {
          Authorization: GetToken()
        }
      })

    const onSubmit = (e) => {
        let body = {
            username: e.username,
            email: e.email,
            location: e.location,
            groupsIds: groupsSelected,
        }

        getRequestMethod(body).then(() => navigate('/users'))
                .catch(err => console.log(err));
    }

    return (
        <div className="container mx-auto">
            <form className="flex flex-col max-w-2xl mx-auto" onSubmit={handleSubmit(onSubmit)}>
                <Tabs aria-label="Options" className="max-w-2xl">
                    <Tab key="user" title="User">
                        <Card>
                            <CardBody>
                                <Input label="Username" className="pb-3" {...register("username", { required: true })}/>
                                <Input label="Email" className="pb-3" disabled={editForm} {...register("email", { required: true })}/>
                                <Input label="Location" className="pb-3" {...register("location", { required: true })}/>
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
                                    >
                                        {group.name}
                                    </Checkbox>)}
                                </CheckboxGroup>
                            </CardBody>
                        </Card>  
                    </Tab>
                </Tabs>

                <div className="flex justify-start">
                    <Button className="m-1" type="submit" color="success">
                        Save
                    </Button>
                    <Button className="m-1" onClick={() => navigate('/users')} color="danger">
                        Cancel
                    </Button>
                </div>
            </form>  
        </div>
    );
}
