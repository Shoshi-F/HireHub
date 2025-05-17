import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AppShell from "./BasicLayout";
import HomePage from "./pages/Home";
import ResumeUpload from "./pages/ResumeUpload";
import UserProfile from "./pages/UserProfile";
import BasicLayout from "./BasicLayout";

const AppRouter: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<BasicLayout />}>
          <Route index element={<HomePage />} />
          <Route path="upload" element={<ResumeUpload />} />
          <Route path="profile" element={<UserProfile />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default AppRouter;
