import { RouterUser } from './router-user';

export class DataEntity{
    constructor(
        public userName: string,
        public userRole: RouterUser[],
        public userCredencial: string
    ){}

}