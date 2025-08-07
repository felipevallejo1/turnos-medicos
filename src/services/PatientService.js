import axios from 'axios';

const API_URL = 'http://localhost:5053/api/patient';

export const getAllPatients = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data.data; // Accede a la propiedad 'data' del ApiResponse
  } catch (error) {
    console.error('Error al obtener pacientes:', error);
    return [];
  }
};
