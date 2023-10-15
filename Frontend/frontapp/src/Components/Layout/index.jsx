import React from 'react';
import NavbarLayout from './NavbarLayout';
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <div className='bg-softwhite h-screen'>
        <NavbarLayout />
        <Outlet />
    </div>
  );
}

export default Layout