import React, { useEffect, useState, useMemo } from "react";
import {Table, TableHeader, TableColumn, TableBody, TableRow, TableCell, Tooltip, Button, User, Chip, CircularProgress, Pagination } from "@nextui-org/react";
import {EditIcon} from "../../Components/Icons/EditIcon.jsx";
import {DeleteIcon} from "../../Components/Icons/DeleteIcon.jsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowRotateLeft } from "@fortawesome/free-solid-svg-icons";
import { useUserStore } from '../../Store/usersStore.jsx'
import { useNavigate } from "react-router-dom";
import { Permission } from '../../Enums/Permission.tsx';
import InformationModal from "../../Components/InformationModal/index.jsx";

const columns = [
  {name: "ID", uid: "id"},
  {name: "USER", uid: "user"},
  {name: "STATUS", uid: "status"},
  {name: "ACTIONS", uid: "actions"}
];

export default function App() {
  const [open, setOpen] = useState(false);
  const [permissions, setPermissions] = useState([])
  useEffect(() => {
    let localPermissions = JSON.parse(localStorage.getItem("permissions"));

    if(!localPermissions){
        return;
    }

    setPermissions(Object.keys(localPermissions))
  }, [setPermissions])
  const navigate = useNavigate();
  const {
    users,
    fetchUsers,
    resetPassword,
    usersIsLoading,
    usersIsError,
    deleteUserIsLoading,
    deleteUserIsError,
    deleteUser
  } = useUserStore((state) => state);

  const [page, setPage] = useState(1);
  const maxItemsPerPage = 8;
  const pages = Math.ceil(users.length / maxItemsPerPage);
  const items = useMemo(() => {
      const start = (page - 1) * maxItemsPerPage;
      const end = start + maxItemsPerPage;
  
      return users.slice(start, end);
    }, [page, users, maxItemsPerPage]);

  useEffect(() => {
    fetchUsers();
  }, [fetchUsers])

  useEffect(() => {
    if(deleteUserIsLoading || deleteUserIsError)
        return setOpen(true)

    setOpen(false)
  }, [deleteUserIsLoading, deleteUserIsError])

  const onReset = (email) => {
    let data = {
        email: email
    };

    resetPassword(data);
  }

  return (
    <div className="mx-auto max-w-5xl pt-10">
      <InformationModal open={open} setOpen={setOpen} title='Delete user'>
        {(deleteUserIsLoading) && <CircularProgress />}
        {(deleteUserIsError) && <p>Error!</p>}
      </InformationModal>
      {permissions.includes(Permission[Permission.AddUser]) && 
      <div className="flex items-end justify-end pb-3">
        <Button onClick={() => navigate("form")} className="bg-green text-white">
          Add New
        </Button>
      </div>}
      <Table bottomContent = {
        <>
        {usersIsLoading && <div className="flex justify-center"><CircularProgress /></div>}
        {usersIsError && <p>Error!</p>}
        <div className="flex justify-center p-5">
            <Pagination
              isCompact
              showControls
              showShadow
              color="success"
              page={page}
              total={pages}
              onChange={(page) => setPage(page)}
            />
          </div>
        </>
      } aria-label="Example table with custom cells">
      <TableHeader columns={columns} className="bg-softpink text-white">
        {(column) => (
          <TableColumn key={column.uid} align="start" className="bg-softpink text-white">
            {column.name}
          </TableColumn>
        )}
      </TableHeader>
      <TableBody items={items}>
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
                {permissions.includes(Permission[Permission.UpdateUser]) && 
                <Tooltip className="text-white" color="success" content="Edit user">
                  <span onClick={() => navigate(`form/${item.id}`)} className="text-lg text-green cursor-pointer active:opacity-50">
                    <EditIcon />
                  </span>
                </Tooltip>}
                {permissions.includes(Permission[Permission.ResetPassword]) && 
                <Tooltip className="text-white" color="warning" content="Reset password">
                <FontAwesomeIcon onClick={() => onReset(item.email)} icon={faArrowRotateLeft} className="text-lg text-warning cursor-pointer active:opacity-50"/>
                </Tooltip>}
                {permissions.includes(Permission[Permission.DeleteUser]) && 
                <Tooltip color="danger" content="Delete user">
                  <span onClick={() => deleteUser(item.id, fetchUsers)} className="text-lg text-danger cursor-pointer active:opacity-50">
                    <DeleteIcon />
                  </span>
                </Tooltip> }
                
              </div>
            </TableCell>
          </TableRow>
        )}
      </TableBody>
      </Table>
    </div>
  );
}