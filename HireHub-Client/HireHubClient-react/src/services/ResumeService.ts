import axios from 'axios';
import { getToken } from './AuthService';

const API_URL = 'https://localhost:7131/api';

export const getResume = async (id: number) => {
    try {
        const token = localStorage.getItem('token');
        const response = await axios.get(`${API_URL}/resume/${id}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    } catch (error) {
        console.error('Error fetching Resume:', error);
        throw error;
    }
};

export const generateUploadUrl = async (contentType: string) => {
    const response = await axios.post(
        `${API_URL}/resume/generate-upload-url`,
        { contentType }, 
        {
            headers: {
                Authorization: `Bearer ${getToken()}`,
                'Content-Type': 'application/json'
            },
        }
    );
    return response.data.presignedUrl.result;
};

export const uploadFileToPresignedUrl = async (presignedUrl: string, file: File) => {
    console.log(presignedUrl)
    await axios.put(presignedUrl, file, {
        headers: {
            'Content-Type': file.type,
        },
    });
};

export const confirmUpload = async (contentType: string) => {
    console.log("confirmUpload");
    const response = await axios.post(
        `${API_URL}/resume/confirm-upload`,
        {  contentType},
        {
            headers: {
                Authorization: `Bearer ${getToken()}`,
            },
        }
    );
    return response.data;
};

export const updatRresume = async (id: string, resumeData: any) => {
    try {
        const token = localStorage.getItem('token');
        const response = await axios.put(`${API_URL}/resume/${id}`, resumeData, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    } catch (error) {
        console.error('Error updating Resume:', error);
        throw error;
    }
};

export const deleteResume = async (id: string) => {
    try {
        const response = await axios.delete(`${API_URL}/resume/${id}`, {
            headers: {
                Authorization: `Bearer ${getToken()}`
            }
        });
        return response.data;
    } catch (error) {
        console.error('Error deleting Resume:', error);
        throw error;
    }
};
