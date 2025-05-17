interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    createdAt: string;
    updatedAt: string;
    hasUploadedGeneralResume: boolean;
};

export default User;