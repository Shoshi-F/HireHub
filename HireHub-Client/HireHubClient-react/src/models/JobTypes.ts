export interface JobPostModel {
    title: string;
    description: string;
    company: string;
    jobrequirements: string;
    jobskills: string;
    yearsOfExperienceRequired: number;
    area: string;
}

export interface Job {
    id: number;
    title: string;
    description: string;
    jobrequirements: string;
    company: string;
    jobskills: string;
    yearsOfExperienceRequired: number;
    area: string;
    recruiterId: number;
    isActive: boolean;
}