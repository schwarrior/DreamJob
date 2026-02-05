export interface Job {
  id?: number;
  title: string;
  description: string;
  companyId: number;
  company?: Company;
  location: string;
  salary?: number;
  postedDate: Date;
  isActive: boolean;
}

export interface Company {
  id?: number;
  name: string;
  description: string;
  location: string;
  website?: string;
  jobs?: Job[];
}

export interface Application {
  id?: number;
  jobId: number;
  job?: Job;
  applicantName: string;
  applicantEmail: string;
  resume?: string;
  coverLetter?: string;
  appliedDate: Date;
  status: string;
}
