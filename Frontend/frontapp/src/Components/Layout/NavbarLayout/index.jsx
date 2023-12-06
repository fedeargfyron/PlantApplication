import React, { useEffect, useState } from "react";
import {Navbar, NavbarBrand, NavbarContent, NavbarItem, Link, Button, NavbarMenuToggle, NavbarMenu, NavbarMenuItem, DropdownItem, DropdownMenu, Avatar, Dropdown, DropdownTrigger} from "@nextui-org/react";
import { useNavigate } from "react-router-dom";
import { useUserStore } from '../../../Store/usersStore.jsx'
import { Permission } from "../../../Enums/Permission.tsx";

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
        <Dropdown placement="bottom-end">
          <DropdownTrigger>
            <Avatar
              isBordered
              as="button"
              className="transition-transform"
              color="primary"
              name="Jason Hughes"
              size="sm"
              src="https://i.pravatar.cc/150?u=a042581f4e29026704d"
            />
          </DropdownTrigger>
          <DropdownMenu aria-label="Profile Actions" variant="flat">
            <DropdownItem key="profile" className="h-14 gap-2">
              <p className="font-semibold">Signed in as</p>
              <p className="font-semibold">zoey@example.com</p>
            </DropdownItem>
            {permissions.includes(Permission[Permission.GetUsers]) && 
              <DropdownItem onClick={() => navigate('/users')} key="users" className="text-softpink">Users</DropdownItem>
            }
            {permissions.includes(Permission[Permission.GetGroups]) && 
              <DropdownItem onClick={() => navigate('/groups')} key="groups" className="text-softpink">Groups</DropdownItem>
            }
            {(permissions.includes(Permission[Permission.GetScansAmount]) || 
            permissions.includes(Permission[Permission.GetLoginsAmount]) ||
            permissions.includes(Permission[Permission.GetCreatedUsersAmount]) ||
            permissions.includes(Permission[Permission.GetHealthyPlantsAmount])) && 
            <DropdownItem onClick={() => navigate('/metrics')} key="metrics" className="text-softpink">Metrics</DropdownItem>
            }
            {permissions.includes(Permission[Permission.GetRankedPlants]) && 
              <DropdownItem onClick={() => navigate('/plants/ranked')} key="rankedplants" className="text-softpink">Ranked plants</DropdownItem>
            }
            {permissions.includes(Permission[Permission.ChangePassword]) && 
              <DropdownItem onClick={() => navigate('/changepassword')} key="changepassword" className="text-softpink">Change password</DropdownItem>
            }
            <DropdownItem onClick={logOut} key="logout" className="text-softpink">
              Log Out
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
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
