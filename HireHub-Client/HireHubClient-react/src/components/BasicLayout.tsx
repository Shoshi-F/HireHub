import { Outlet } from 'react-router-dom';
import TopNav from './TopNav'; 
import '../styles/BasicLayout.css'; 

const BasicLayout = () => {
    return (
        <div style={{ "width": "100vw" }} className="basic-layout">
            <TopNav />
            <div className="content">
                <Outlet />
            </div>
        </div>
    );
}

export default BasicLayout;