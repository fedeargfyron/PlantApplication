import React, { useEffect, useState, useMemo } from "react";
import {Table, TableHeader, TableColumn, TableBody, TableRow, TableCell, Tooltip, Button, CircularProgress, Pagination } from "@nextui-org/react";
import {EditIcon} from "../../Components/Icons/EditIcon.jsx";
import {DeleteIcon} from "../../Components/Icons/DeleteIcon.jsx";
import { useGroupStore } from '../../Store/groupsStore.jsx'
import { Permission } from '../../Enums/Permission.tsx';
import { useNavigate } from "react-router-dom";
import InformationModal from "../../Components/InformationModal/index.jsx";

const columns = [
  {name: "ID", uid: "id"},
  {name: "NAME", uid: "name"},
  {name: "ACTIONS", uid: "actions"}
];

export default function App() {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [permissions, setPermissions] = useState([]);
  let { 
    groups,
    groupsIsLoading,
    groupsIsError,
    fetchGroups,
    deleteGroup,
    deleteGroupIsLoading,
    deleteGroupIsError,
  } = useGroupStore(state => state);
  useEffect(() => {
    fetchGroups();
  }, [fetchGroups])

  const [page, setPage] = useState(1);
  const maxItemsPerPage = 8;
  const pages = Math.ceil(groups.length / maxItemsPerPage);
  const items = useMemo(() => {
      const start = (page - 1) * maxItemsPerPage;
      const end = start + maxItemsPerPage;
  
      return groups.slice(start, end);
    }, [page, groups, maxItemsPerPage]);

  useEffect(() => {
    if(deleteGroupIsLoading || deleteGroupIsError)
        return setOpen(true)

    setOpen(false)
  }, [deleteGroupIsLoading, deleteGroupIsError])

  useEffect(() => {
    let localPermissions = JSON.parse(localStorage.getItem("permissions"));

    if(!localPermissions){
        return;
    }

    setPermissions(Object.keys(localPermissions));
  }, [setPermissions])

  return (
    <div className="mx-auto max-w-5xl pt-10">
      <InformationModal open={open} setOpen={setOpen}>
        {(deleteGroupIsLoading) && <CircularProgress />}
        {(deleteGroupIsError) && <p>Error!</p>}
      </InformationModal>
      {permissions.includes(Permission[Permission.AddGroup]) && 
      <div className="flex items-end justify-end pb-3">
        <Button onClick={() => navigate("form")} className="bg-green text-white">
          Add New
        </Button>
      </div> }
      <Table bottomContent={
        <>
        {groupsIsLoading && <div className="flex justify-center"><CircularProgress /></div>}
        {groupsIsError && <p>Error!</p>}
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
          <TableColumn key={column.uid} align="start" className="bg-softpink text-white" color="white">
            {column.name}
          </TableColumn>
        )}
      </TableHeader>
        <TableBody items={items}>
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
                {permissions.includes(Permission[Permission.UpdateGroup]) && 
                <Tooltip className="text-white" color="success" content="Edit group">
                  <span onClick={() => navigate(`form/${item.id}`)} className="text-lg text-green cursor-pointer active:opacity-50">
                    <EditIcon />
                  </span>
                </Tooltip>}
                {permissions.includes(Permission[Permission.DeleteGroup]) && 
                <Tooltip color="danger" content="Delete group">
                  <span onClick={() => deleteGroup(item.id, fetchGroups)} className="text-lg text-danger cursor-pointer active:opacity-50">
                    <DeleteIcon />
                  </span>
                </Tooltip>}
              </div>
            </TableCell>
          </TableRow>
        )}
        </TableBody>
      </Table>
    </div>
  );
}