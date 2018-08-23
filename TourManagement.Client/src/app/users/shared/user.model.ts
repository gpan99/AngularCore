
export class User {
    id?: string;
    firstname: string;
    lastname: string;
    phone: string;
    department?: Department;
}
export class Department {
    id: string;
    name: string;
}
