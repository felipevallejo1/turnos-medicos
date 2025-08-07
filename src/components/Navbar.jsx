import React from 'react';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const Navbar = () => {
  const navigate = useNavigate();

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography
          variant="h6"
          sx={{ flexGrow: 1, cursor: 'pointer' }}
          onClick={() => navigate('/')}
        >
          Turnos Médicos
        </Typography>

        <Button color="inherit" onClick={() => navigate('/pacientes')}>
          Lista de Pacientes
        </Button>

        <Button color="inherit" onClick={() => navigate('/buscar-doctor')}>
          Buscar Doctor
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
