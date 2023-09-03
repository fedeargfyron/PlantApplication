import { Outlet } from "react-router-dom"

function Root() {
    return (
      <div className="text-black">
        <Outlet />
      </div>
    )
  }
  
  export default Root
