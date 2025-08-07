import React from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
  Box,
  Button
} from '@mui/material';

const formatFecha = (fechaISO) => {
  const fecha = new Date(fechaISO);
  return fecha.toLocaleDateString('es-AR'); // Ej: 22/05/1990
};

const PatientList = ({ pacientes, onNuevoPaciente }) => {
  return (
    <Paper elevation={3} sx={{ padding: 2 }}>
      <Box display="flex" justifyContent="space-between" alignItems="center" marginBottom={2}>
        <Typography variant="h6">Lista de Pacientes</Typography>
        <Button variant="contained" onClick={onNuevoPaciente}>
          Nuevo Paciente
        </Button>
      </Box>

      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell><strong>Nombre</strong></TableCell>
              <TableCell><strong>Apellido</strong></TableCell>
              <TableCell><strong>DNI</strong></TableCell>
              <TableCell><strong>Email</strong></TableCell>
              <TableCell><strong>Fecha de nacimiento</strong></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Array.isArray(pacientes) && pacientes.length > 0 ? (
              pacientes.map((p, index) => (
                <TableRow key={index}>
                  <TableCell>{p.name}</TableCell>
                  <TableCell>{p.lastName}</TableCell>
                  <TableCell>{p.dni}</TableCell>
                  <TableCell>{p.email}</TableCell>
                  <TableCell>{formatFecha(p.birthDate)}</TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={5} align="center">
                  No hay pacientes cargados
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
  );
};

export default PatientList;
