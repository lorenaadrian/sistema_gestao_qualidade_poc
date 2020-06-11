import { DataEntity } from './data-entity';

export class AuthorizationUser {
    constructor( 
        public isAuthorized: string,
        public accessToken: string,
        public isValid: string,
        public message: string,
        public dataEntity:  DataEntity
    ){}
}