import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, useNavigate } from 'react-router-dom';
import { Container } from '@mui/material';
import { SnackbarProvider, useSnackbar } from 'notistack';

import PatientList from './components/PatientList';
import PatientForm from './components/PatientForm';
import Navbar from './components/Navbar';
import BuscarDoctor from './components/BuscarDoctor';

function AppContent() {
  const [pacientes, setPacientes] = useState([]);
  const [formOpen, setFormOpen] = useState(false);
  const navigate = useNavigate();
  const { enqueueSnackbar } = useSnackbar(); // 👈 Hook de notistack

  const cargarPacientes = async () => {
    try {
      const res = await fetch('http://localhost:5053/api/Patient');
      const json = await res.json();
      console.log("Pacientes recibidos:", json.data);
      setPacientes(json.data);
    } catch (error) {
      console.error("Error al cargar pacientes:", error);
    }
  };

  useEffect(() => {
    cargarPacientes();
  }, []);

  const guardarPaciente = async (nuevoPaciente) => {
    try {
      console.log("Enviando a la API:", nuevoPaciente);
      const res = await fetch('http://localhost:5053/api/Patient', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(nuevoPaciente)
      });

      if (res.ok) {
        enqueueSnackbar('Paciente creado con éxito', { variant: 'success' }); // ✅ Toast
        setFormOpen(false);
        cargarPacientes();
      } else {
        enqueueSnackbar('Error al crear paciente', { variant: 'error' }); // ❌ Toast de error
      }
    } catch (error) {
      console.error("Error al guardar paciente:", error);
      enqueueSnackbar('Ocurrió un error inesperado', { variant: 'error' });
    }
  };

  return (
    <>
      <Navbar />
      <Container maxWidth="md" sx={{ paddingTop: 4 }}>
        <Routes>
          <Route
            path="/"
            element={<div style={{ textAlign: 'center', marginTop: 50 }}>Bienvenido al sistema de turnos médicos</div>}
          />
          <Route
            path="/pacientes"
            element={
              <>
                <PatientList pacientes={pacientes} onNuevoPaciente={() => setFormOpen(true)} />
                <PatientForm
                  open={formOpen}
                  onClose={() => setFormOpen(false)}
                  onGuardar={guardarPaciente}
                />
              </>
            }
          />
          <Route
            path="/buscar-doctor"
            element={<BuscarDoctor />}
          />
        </Routes>
      </Container>
    </>
  );
}

// Envolvemos la App con el proveedor de notistack
function App() {
  return (
    <SnackbarProvider anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}>
      <Router>
        <AppContent />
      </Router>
    </SnackbarProvider>
  );
}

export default App;
