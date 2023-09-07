import React, { useEffect } from "react";
import {Table, TableHeader, TableColumn, TableBody, TableRow, TableCell, Tooltip, Button } from "@nextui-org/react";
import {EditIcon} from "../../Components/Icons/EditIcon.jsx";
import {DeleteIcon} from "../../Components/Icons/DeleteIcon.jsx";
import {EyeIcon} from "../../Components/Icons/EyeIcon.jsx";
import { useGroupStore } from '../../Store/groupsStore.jsx'
import { useNavigate } from "react-router-dom";
import { GetToken } from '../../Components/Helpers/TokenHelper.jsx';
import axios from 'axios';

const columns = [
  {name: "ID", uid: "id"},
  {name: "NAME", uid: "name"},
  {name: "ACTIONS", uid: "actions"}
];

export default function App() {

  const navigate = useNavigate();
  const fetchGroups = useGroupStore((state) => state.fetchGroups);
  let groups = useGroupStore(state => state.groups);
  useEffect(() => {
    fetchGroups();
  }, [fetchGroups])

  const deleteGroup = (id) => {
    axios.delete(`https://localhost:44374/groups/${id}`, {
        headers: {
          Authorization: GetToken()
        }
      })
      .then(() => fetchGroups())
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
          <TableColumn key={column.uid} align={column.uid === "actions" ? "center" : "start"}>
            {column.name}
          </TableColumn>
        )}
      </TableHeader>
      <TableBody items={groups}>
        {(item) => (
          <TableRow key={item.id}>
            <TableCell>{item.id}</TableCell>
            <TableCell>
              <div className="flex flex-col">
                <p className="text-bold text-sm capitalize">{item.name}</p>
                <p className="text-bold text-sm capitalize text-default-400">{item.description}</p>
              </div>
            </TableCell>
            <TableCell>
              <div className="relative flex items-center gap-2">
                <Tooltip content="Details">
                  <span className="text-lg text-default-400 cursor-pointer active:opacity-50">
                    <EyeIcon />
                  </span>
                </Tooltip>
                <Tooltip content="Edit user">
                  <span onClick={() => navigate(`form/${item.id}`)} className="text-lg text-primary cursor-pointer active:opacity-50">
                    <EditIcon />
                  </span>
                </Tooltip>
                <Tooltip color="danger" content="Delete user">
                  <span onClick={() => deleteGroup(item.id)} className="text-lg text-danger cursor-pointer active:opacity-50">
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