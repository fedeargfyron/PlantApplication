import React from 'react';
import NavbarLayout from './NavbarLayout';
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <div>
        <NavbarLayout />
        <Outlet />
    </div>
  );
}

export default Layout