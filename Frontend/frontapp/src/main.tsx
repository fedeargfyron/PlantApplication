import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Login from './Screens/Login/index.jsx'
import RouteGuard from './Components/RouteGuard/index.jsx'
import MultipleRouteGuard from './Components/MultipleRouteGuard/index.jsx'
import { Permission } from './Enums/Permission.tsx'
import Layout from './Components/Layout/index.jsx'
import { NextUIProvider } from '@nextui-org/react'
import Home from './Screens/Home/index.jsx'
import Root from './root.tsx'
import Groups from './Screens/Groups/index.jsx'
import GroupForm from './Screens/Groups/GroupForm/index.jsx'
import Users from './Screens/Users/index.jsx'
import UserForm from './Screens/Users/UserForm/index.jsx'
import Plants from './Screens/Plants/index.jsx'
import Calendar from './Screens/Calendar/index.jsx'
import Plant from './Screens/Plant/index.jsx'
import Metrics from './Screens/Metrics/index.jsx'
import Register from './Screens/Register/index.jsx'
import RankedPlants from './Screens/RankedPlants/index.jsx'
import ChangePassword from './Screens/ChangePassword/index.jsx'


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
                element:
                <RouteGuard permission={Permission[Permission.GetGroups]}>
                  <Groups />
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
                path: "/changepassword",
                element: 
                <RouteGuard permission={Permission[Permission.ChangePassword]}>
                  <ChangePassword />
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
              },
              {
                path: "/plants",
                element:
                <RouteGuard permission={Permission[Permission.GetPlants]}>
                  <Plants />
                </RouteGuard>
              },
              {
                path: "/calendar",
                element: 
                <RouteGuard permission={Permission[Permission.GetWateringCalendar]}>
                  <Calendar />
                </RouteGuard>
              },
              {
                path: "/plants/:id",
                element: 
                <RouteGuard permission={Permission[Permission.GetPlantById]}>
                  <Plant />
                </RouteGuard>
              },
              {
                path: "/plants/ranked",
                element: 
                <RouteGuard permission={Permission[Permission.GetRankedPlants]}>
                  <RankedPlants />
                </RouteGuard>
              },
              {
                path: "/metrics/",
                element: 
                <MultipleRouteGuard permissions={[
                  Permission[Permission.GetLoginsAmount], 
                  Permission[Permission.GetHealthyPlantsAmount], 
                  Permission[Permission.GetCreatedUsersAmount], 
                  Permission[Permission.GetScansAmount]]}
                >
                  <Metrics />
                </MultipleRouteGuard>
              }
            ]
          },
          {
            path: "/login",
            element: <Login />
          },
          {
            path: "/register",
            element: <Register />
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
