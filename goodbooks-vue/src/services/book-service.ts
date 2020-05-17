import axios from 'axios';
import IBook from '@/types/Book';
export default class BookService {
    API_URL = process.env.VUE_APP_AIP_URL;
    public async GetAllBooks(): Promise<IBook[]>{
        let result = await axios.get(`${this.API_URL}/books/`)
        return result.data;
    }
}