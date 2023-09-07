import React, { useEffect } from "react";
import {Table, TableHeader, TableColumn, TableBody, TableRow, TableCell, Tooltip, Button, User, Chip } from "@nextui-org/react";
import {EditIcon} from "../../Components/Icons/EditIcon.jsx";
import {DeleteIcon} from "../../Components/Icons/DeleteIcon.jsx";
import { useUserStore } from '../../Store/usersStore.jsx'
import { useNavigate } from "react-router-dom";
import { GetToken } from '../../Components/Helpers/TokenHelper.jsx';
import axios from 'axios';

const columns = [
  {name: "ID", uid: "id"},
  {name: "USER", uid: "user"},
  {name: "STATUS", uid: "status"},
  {name: "ACTIONS", uid: "actions"}
];

export default function App() {

  const navigate = useNavigate();
  const fetchUsers = useUserStore((state) => state.fetchUsers);
  let users = useUserStore(state => state.users);
  useEffect(() => {
    fetchUsers();
  }, [fetchUsers])

  const deleteUser = (id) => {
    axios.delete(`https://localhost:44374/users/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(() => fetchUsers())
      .catch(err => console.log(err));
  }

  return (
    <div className="mx-auto max-w-5xl">
      <div className="flex items-end justify-end pb-3">
        <Button onClick={() => navigate("form")} color="primary">
                Add New
        </Button>
      </div>
      <Table aria-label="Example table with custom cells">
      <TableHeader columns={columns}>
        {(column) => (
          <TableColumn key={column.uid} align="start">
            {column.name}
          </TableColumn>
        )}
      </TableHeader>
      <TableBody items={users}>
        {(item) => (
          <TableRow key={item.id}>
            <TableCell>{item.id}</TableCell>
            <TableCell>
            <div className="w-full flex justify-between text-center items-center gap-2">
                <User
                name={item.username}
                description={item.email}
                />
            </div>
            </TableCell>
            <TableCell>
              <Chip color={item.isDeleted ? 'danger' :'success'}  variant="flat">
                  {item.isDeleted ? 'Deleted' : 'Active'}
              </Chip>
            </TableCell>
            <TableCell>
              <div className="relative flex items-center gap-2">
                <Tooltip content="Edit user">
                  <span onClick={() => navigate(`form/${item.id}`)} className="text-lg text-primary cursor-pointer active:opacity-50">
                    <EditIcon />
                  </span>
                </Tooltip>
                <Tooltip color="danger" content="Delete user">
                  <span onClick={() => deleteUser(item.id)} className="text-lg text-danger cursor-pointer active:opacity-50">
                    <DeleteIcon />
                  </span>
                </Tooltip>
              </div>
            </TableCell>
          </TableRow>
        )}
      </TableBody>
      </Table>
    </div>
  );
}