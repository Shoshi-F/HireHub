import { AppBar, Toolbar, Button, Typography } from '@mui/material';
import { Link, useLocation } from 'react-router-dom';
import SignOutIcon from '@mui/icons-material/ExitToApp';
import SignInIcon from '@mui/icons-material/Login';

const TopNav: React.FC = () => {
    const location = useLocation();
    const isLoggedIn = true; // דוגמה למצב חיבור

    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" sx={{ flexGrow: 1 }}>
                    MySite
                </Typography>
                <Button component={Link} to="/">Home</Button>
                {isLoggedIn ? (
                    <Button startIcon={<SignOutIcon />} onClick={() => {}}>
                        Logout
                    </Button>
                ) : (
                    <Button startIcon={<SignInIcon />} component={Link} to="/login">
                        Login
                    </Button>
                )}
            </Toolbar>
        </AppBar>
    );
};

export default TopNav;
