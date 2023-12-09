import React, { useEffect, useState } from "react";
import { Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button, NavbarMenuToggle, NavbarMenu, NavbarMenuItem } from "@nextui-org/react";
import { useNavigate } from "react-router-dom";
import { useUserStore } from '../../../Store/usersStore.jsx'
import { Permission } from "../../../Enums/Permission.tsx";
import DropdownBuilder from "../../DropdownBuilder/index.jsx";

export default function NavbarLayout() {
  const [isMenuOpen, setIsMenuOpen] = React.useState(false);
  const [permissions, setPermissions] = useState([]);
  const token = localStorage.getItem('token');
  const navigate = useNavigate();
  const { logout } = useUserStore((state) => state);
  const menuItems = [
    "Profile",
    "Dashboard",
    "Activity",
    "Analytics",
    "System",
    "Deployments",
    "My Settings",
    "Team Settings",
    "Help & Feedback",
    "Log Out",
  ];

  useEffect(() => {
    let localPermissions = JSON.parse(localStorage.getItem("permissions"));

    if(!localPermissions){
        return;
    }

    setPermissions(Object.keys(localPermissions));
  }, [setPermissions])
  
  const logOut = () => {
    localStorage.removeItem('token');
    navigate('/login');
    logout();
  }

  const getDropdown = () => {
    var builder = new DropdownBuilder();

    if(permissions.includes(Permission[Permission.GetUsers])){
      builder.setUsers();
    }

    if(permissions.includes(Permission[Permission.GetGroups])){
      builder.setGroups();
    }

    if(permissions.includes(Permission[Permission.GetScansAmount]) || 
      permissions.includes(Permission[Permission.GetLoginsAmount]) ||
      permissions.includes(Permission[Permission.GetCreatedUsersAmount]) ||
      permissions.includes(Permission[Permission.GetHealthyPlantsAmount])){
      builder.setMetrics();
    }

    if(permissions.includes(Permission[Permission.GetRankedPlants])){
      builder.setRankedPlants();
    }

    if(permissions.includes(Permission[Permission.ChangePassword])){
      builder.setChangePassword();
    }



    return builder.build(navigate, logOut);
  }

  return (
    <Navbar onMenuOpenChange={setIsMenuOpen} className="text-softpink">
      <NavbarContent>
        <NavbarMenuToggle
          aria-label={isMenuOpen ? "Close menu" : "Open menu"}
          className="sm:hidden"
        />
        <NavbarBrand>
          <Link className="text-softpink text-xl font-bold" href="/">
            MyPlantCare
          </Link>
        </NavbarBrand>
      </NavbarContent>
      {!token && 
      <NavbarContent justify="end">
        <NavbarItem className="hidden lg:flex">
          <Link className="text-softpink" href="/login">Login</Link>
        </NavbarItem>
        <NavbarItem>
          <Button as={Link} className="bg-gradient-to-tr from-green-500 to-teal-500 text-softpink" color="primary" href="/register" variant="flat">
            Sign Up
          </Button>
        </NavbarItem>
      </NavbarContent>}
      {token && 
      <>
        {permissions.includes(Permission[Permission.GetWateringCalendar]) && 
          <NavbarContent className="hidden sm:flex gap-4 text-xl" justify="center">
            <NavbarItem isActive>
              <Link className="text-softpink text-xl" href="/calendar">
              Calendar
              </Link>
            </NavbarItem>
          </NavbarContent>
        }
        {permissions.includes(Permission[Permission.GetPlants]) && 
          <NavbarContent className="hidden sm:flex gap-4 text-xl" justify="center">
          <NavbarItem isActive>
            <Link className="text-softpink text-xl" href="/plants">
              My Plants
            </Link>
          </NavbarItem>
        </NavbarContent>
        }
        {getDropdown()}
      </>
      }
      <NavbarMenu>
        {menuItems.map((item, index) => (
          <NavbarMenuItem key={`${item}-${index}`}>
            <Link
              color={
                index === 2 ? "primary" : index === menuItems.length - 1 ? "danger" : "foreground"
              }
              className="w-full"
              href="#"
              size="lg"
            >
              {item}
            </Link>
          </NavbarMenuItem>
        ))}
      </NavbarMenu>
    </Navbar>
  );
}
