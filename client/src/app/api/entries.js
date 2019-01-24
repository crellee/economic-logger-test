import axios from 'axios';

const client = axios.create({ baseURL: 'http://localhost:3001/api' });

const create = async (data) => {
    const response = await client.post('/timelogs', data)
    return response.data
} 

export default {
    create
}