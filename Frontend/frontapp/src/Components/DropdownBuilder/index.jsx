import { Dropdown, DropdownMenu, DropdownItem, DropdownTrigger, Avatar } from "@nextui-org/react";
export default class DropdownBuilder {
  constructor() {
      this.users = false;
      this.groups = false;
      this.metrics = false;
      this.rankedPlants = false;
      this.changePassword = false;
    }
    setUsers() {
      this.users = true;
      return this;
    }
    setGroups() {
      this.groups = true;
      return this;
    }
    setMetrics() {
      this.metrics = true;
      return this;
    }
    setRankedPlants() {
      this.rankedPlants = true;
      return this;
    }
    setChangePassword() {
      this.changePassword = true;
      return this;
    }
    build(navigate, logOut) {
      return (<Dropdown placement="bottom-end">
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
        {this.users && 
          <DropdownItem onClick={() => navigate('/users')} key="users" className="text-softpink">Users</DropdownItem>
        }
        {this.groups && 
          <DropdownItem onClick={() => navigate('/groups')} key="groups" className="text-softpink">Groups</DropdownItem>
        }
        {this.metrics && 
        <DropdownItem onClick={() => navigate('/metrics')} key="metrics" className="text-softpink">Metrics</DropdownItem>
        }
        {this.rankedPlants && 
          <DropdownItem onClick={() => navigate('/plants/ranked')} key="rankedplants" className="text-softpink">Ranked plants</DropdownItem>
        }
        {this.changePassword && 
          <DropdownItem onClick={() => navigate('/changepassword')} key="changepassword" className="text-softpink">Change password</DropdownItem>
        }
        <DropdownItem onClick={logOut} key="logout" className="text-softpink">
          Log Out
        </DropdownItem>
      </DropdownMenu>
    </Dropdown>);
    }
  }