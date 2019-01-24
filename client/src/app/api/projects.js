import axios from 'axios';

const client = axios.create({ baseURL: 'http://localhost:3001/api' });

const get = async (id) => {
	const response = await client.get(`/projects/${id}`)
	return response.data
}

const getAll = async () => {
	const response = await client.get('/projects')
	return response.data
}

const find = async (searchText) => {
	const response = await client.get(`/projects/search/${searchText}`)
	return response.data
}

export default {
	get,
	getAll,
	find
}
