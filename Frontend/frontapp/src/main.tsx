import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Login from './Screens/Login/index.jsx'
import RouteGuard from './Components/RouteGuard/index.jsx'
import { Permission } from './Enums/Permission.tsx'
import Layout from './Components/Layout/index.jsx'
import { NextUIProvider } from '@nextui-org/react'
import Home from './Screens/Home/index.jsx'
import Root from './root.tsx'
import Groups from './Screens/Groups/index.jsx'
import GroupForm from './Screens/Groups/GroupForm/index.jsx'
import Users from './Screens/Users/index.jsx'
import UserForm from './Screens/Users/UserForm/index.jsx'


const router = createBrowserRouter([
      {
        path: "/",
        element: <Root/>,
        children: [
          {
            path: "/",
            element: <Layout/>,
            children: [
              {
                path: "/",
                element: <Home />
              },
              {
                path: "/groups",
                element: <Groups />
              },
              {
                path: "/test",
                element: 
                <RouteGuard permission={Permission[Permission.Login]}>
                  <Login />
                </RouteGuard>
              },
              {
                path: "/groups/form",
                element: 
                <RouteGuard permission={Permission[Permission.AddGroup]}>
                  <GroupForm />
                </RouteGuard>
              },
              {
                path: "/groups/form/:id",
                element: 
                <RouteGuard permission={Permission[Permission.UpdateGroup]}>
                  <GroupForm />
                </RouteGuard>
              },
              {
                path: "/users",
                element: 
                <RouteGuard permission={Permission[Permission.GetUsers]}>
                  <Users />
                </RouteGuard>
              },
              {
                path: "/users/form",
                element: 
                <RouteGuard permission={Permission[Permission.AddUser]}>
                  <UserForm />
                </RouteGuard>
              },
              {
                path: "/users/form/:id",
                element: 
                <RouteGuard permission={Permission[Permission.UpdateUser]}>
                  <UserForm />
                </RouteGuard>
              }
            ]
          },
          {
            path: "/login",
            element: <Login />
          }
        ]
    },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
      <NextUIProvider>
        <RouterProvider router={router} />
      </NextUIProvider>
    </React.StrictMode>
)
