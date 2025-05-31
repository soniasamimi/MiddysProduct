import axios from 'axios';

const API_BASE_URL = '/api/products';

export const getProducts = () => axios.get(API_BASE_URL);
export const createProduct = (data) => axios.post(API_BASE_URL, data);
export const updateProduct = (id, data) => axios.put(`${API_BASE_URL}/${id}`, data);
export const deleteProduct = (id) => axios.delete(`${API_BASE_URL}/${id}`);
