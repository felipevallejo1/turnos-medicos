import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button
} from '@mui/material';

const PatientForm = ({ open, onClose, onGuardar }) => {
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');
  const [dni, setDni] = useState('');
  const [email, setEmail] = useState('');
  const [fechaNacimiento, setFechaNacimiento] = useState('');

  const handleSave = () => {
    if (!nombre || !apellido || !dni || !email || !fechaNacimiento) {
      alert("Todos los campos son obligatorios");
      return;
    }

    const nuevoPaciente = {
      name: nombre,
      lastname: apellido,
      dni,
      email,
      birthdate: fechaNacimiento
    };

    onGuardar(nuevoPaciente); // ✅ Llamamos a la función del padre
    setNombre('');
    setApellido('');
    setDni('');
    setEmail('');
    setFechaNacimiento('');
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Nuevo Paciente</DialogTitle>
      <DialogContent>
        <TextField label="Nombre" fullWidth margin="dense" value={nombre} onChange={(e) => setNombre(e.target.value)} />
        <TextField label="Apellido" fullWidth margin="dense" value={apellido} onChange={(e) => setApellido(e.target.value)} />
        <TextField label="DNI" fullWidth margin="dense" value={dni} onChange={(e) => setDni(e.target.value)} />
        <TextField label="Email" fullWidth margin="dense" value={email} onChange={(e) => setEmail(e.target.value)} />
        <TextField label="Fecha de nacimiento" fullWidth margin="dense" type="date" InputLabelProps={{ shrink: true }} value={fechaNacimiento} onChange={(e) => setFechaNacimiento(e.target.value)} />
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose}>Cancelar</Button>
        <Button variant="contained" onClick={handleSave}>Guardar</Button>
      </DialogActions>
    </Dialog>
  );
};

export default PatientForm;
