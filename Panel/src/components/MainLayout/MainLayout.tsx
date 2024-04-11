import { Outlet, NavLink } from "react-router-dom";

function MainLayout() {
  return (
    <>
      <div className="w3-w3-container">
        <label>Main Layout</label>
      </div>
      <div className="w3-w3-container">
        <label>Another Layouts</label>
        <div>
          <Outlet />
        </div>
      </div>
    </>
  );
}

export default MainLayout;
