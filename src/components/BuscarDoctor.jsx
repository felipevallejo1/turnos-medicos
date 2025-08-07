import React, { useState } from 'react';
import {
  Paper,
  Typography,
  TextField,
  MenuItem,
  List,
  ListItem,
  ListItemText,
  Box
} from '@mui/material';

const especialidadesDisponibles = [
  'Pediatría',
  'Cardiología',
  'Dermatología',
  'Ginecología',
  'Clínica Médica'
];

const doctoresMock = [
  { nombre: 'Dra. Ana Torres', especialidad: 'Pediatría' },
  { nombre: 'Dr. Jorge Gómez', especialidad: 'Cardiología' },
  { nombre: 'Dra. Lucía Paz', especialidad: 'Dermatología' },
  { nombre: 'Dr. Carlos Ruiz', especialidad: 'Clínica Médica' },
  { nombre: 'Dra. María López', especialidad: 'Ginecología' },
  { nombre: 'Dr. Pablo Fernández', especialidad: 'Cardiología' }
];

const BuscarDoctor = () => {
  const [especialidadSeleccionada, setEspecialidadSeleccionada] = useState('');

  const doctoresFiltrados = doctoresMock.filter(
    (doc) => doc.especialidad === especialidadSeleccionada
  );

  return (
    <Paper elevation={3} sx={{ padding: 3 }}>
      <Typography variant="h6" gutterBottom>
        Buscar Doctor por Especialidad
      </Typography>

      <TextField
        select
        label="Especialidad"
        fullWidth
        margin="normal"
        value={especialidadSeleccionada}
        onChange={(e) => setEspecialidadSeleccionada(e.target.value)}
      >
        {especialidadesDisponibles.map((esp) => (
          <MenuItem key={esp} value={esp}>
            {esp}
          </MenuItem>
        ))}
      </TextField>

      {especialidadSeleccionada && (
        <Box marginTop={2}>
          <Typography variant="subtitle1">
            Doctores disponibles en {especialidadSeleccionada}:
          </Typography>

          {doctoresFiltrados.length > 0 ? (
            <List>
              {doctoresFiltrados.map((doc, index) => (
                <ListItem key={index}>
                  <ListItemText primary={doc.nombre} />
                </ListItem>
              ))}
            </List>
          ) : (
            <Typography>No hay doctores registrados en esta especialidad.</Typography>
          )}
        </Box>
      )}
    </Paper>
  );
};

export default BuscarDoctor;
