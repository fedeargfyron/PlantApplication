import React from "react";
import Calendar from "../../Components/Calendar";

export default function App() {

  return (
    <div className="mx-auto max-w-5xl pt-10 flex flex-col">
        <Calendar />
        <div className="info grid grid-cols-4">
          <div className="bg-white p-1">
            <p>Date</p>
            <p>Plant</p>
          </div>
          <div className="bg-white p-1"></div>
          <div className="bg-white p-1"></div>
          <div className="bg-white p-1"></div>
        </div>
    </div>
  );
}