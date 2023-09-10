import React, { useState, useEffect } from "react";
import {Tabs, Tab, Card, CardBody, Input, Textarea, Button, CheckboxGroup, Checkbox, User, Chip} from "@nextui-org/react";
import { useForm } from 'react-hook-form'
import { useGroupStore } from '../../../Store/groupsStore.jsx'
import { useUserStore } from '../../../Store/usersStore.jsx'
import { usePermissionStore } from '../../../Store/permissionsStore.jsx'
import { useNavigate, useParams } from 'react-router-dom'
import { Permission } from '../../../Enums/Permission.tsx'
import { GetToken } from '../../../Components/Helpers/TokenHelper.jsx';

import axios from 'axios'

export default function GroupForm() {
    const [editForm, setEditForm] = useState(false);
    const { register, setValue, handleSubmit } = useForm();
    const [usersSelected, setUsersSelected] = useState([]);
    const [permissionsSelected, setPermissionsSelected] = useState([]);
    const navigate = useNavigate();
    const params = useParams();
    const id = params.id;

    const fetchGroupById = useGroupStore((state) => state.fetchGroupById);
    let group = useGroupStore(state => state.group);

    const fetchUsers = useUserStore((state) => state.fetchUsers);
    let users = useUserStore(state => state.users);

    const fetchPermissions = usePermissionStore((state) => state.fetchPermissions);
    let permissions = usePermissionStore(state => state.permissions);

    useEffect(() => {
        fetchUsers();
    }, [fetchUsers]);

    useEffect(() => {
        fetchPermissions();
    }, [fetchPermissions]);

    useEffect(() => {
        if (id) fetchGroupById(id);
    }, [id, fetchGroupById]);

    useEffect(() => {
        if(!id)
            return;

        if(!group)
            return;

        setValue("name", group.name);
        setValue("description", group.description);
        setPermissionsSelected(group.permissionsIds);
        setUsersSelected(group.usersIds);
        setEditForm(true);
    }, [group, id, setValue, setEditForm]);

    const getRequestMethod = (body) => editForm ? axios.put(`https://localhost:44374/groups/${id}`, body,{
        headers: {
          Authorization: GetToken()
        }
      }) : axios.post('https://localhost:44374/groups', body, {
        headers: {
          Authorization: GetToken()
        }
      })

    const onSubmit = (e) => {
        let body = {
            name: e.name,
            description: e.description,
            usersIds: usersSelected,
            permissionsIds: permissionsSelected
        }

        getRequestMethod(body).then(() => navigate('/groups'))
                .catch(err => console.log(err));
    }

    return (
        <div className="container mx-auto">
            <form className="flex flex-col max-w-2xl mx-auto" onSubmit={handleSubmit(onSubmit)}>
                <Tabs aria-label="Options" className="max-w-2xl">
                    <Tab key="group" title="Group">
                        <Card>
                            <CardBody>
                                <Input type="text" label="Name" className="pb-3" {...register("name", { required: true })}/>
                                <Textarea
                                    isRequired
                                    label="Description"
                                    labelPlacement="outside"
                                    placeholder="Enter your description"
                                    {...register("description", { required: true })}
                                />
                            </CardBody>
                        </Card>  
                    </Tab>
                    <Tab key="permissions" title="Permissions">
                        <Card>
                            <CardBody>
                            <CheckboxGroup
                                onChange={setPermissionsSelected}
                                label="Select permissions"
                                defaultValue={permissionsSelected}
                                >
                                {permissions && permissions.map(permission => 
                                <Checkbox
                                    value={permission.id}
                                    key={permission.id}
                                >
                                    {Permission[permission.value]}
                                </Checkbox>)}
                            </CheckboxGroup>
                            </CardBody>
                        </Card>  
                    </Tab>
                    <Tab key="users" title="Users">
                        <Card>
                            <CardBody>
                                <CheckboxGroup
                                    onChange={setUsersSelected}
                                    label="Select users"
                                    defaultValue={usersSelected}
                                    >
                                    {users && users.map(user => 
                                    <Checkbox
                                        value={user.id}
                                        key={user.id}
                                    >
                                        <div className="w-full flex justify-between text-center items-center gap-2">
                                            <User
                                            name={user.username}
                                            description={user.email}
                                            />
                                            <Chip color={user.isDeleted ? 'danger' :'success'}  variant="flat">
                                                {user.isDeleted ? 'Deleted' : 'Active'}
                                            </Chip>
                                        </div>
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
                    <Button className="m-1" onClick={() => navigate('/groups')} color="danger">
                        Cancel
                    </Button>
                </div>
            </form>  
        </div>
    );
}
