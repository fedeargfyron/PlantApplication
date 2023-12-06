import React from 'react';
import NavbarLayout from './NavbarLayout/index.jsx';
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <div className='bg-softwhite min-h-screen'>
        <NavbarLayout />
        <Outlet />
    </div>
  );
}

export default Layout