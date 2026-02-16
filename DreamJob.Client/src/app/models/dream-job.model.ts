export interface DreamJob {
  id: number;
  title: string;
  jobDetails: string;
  skills: string[];
  createdDate: Date;
  lastModifiedDate: Date;
}

export interface CreateDreamJob {
  title: string;
  jobDetails: string;
  skills: string[];
}

export interface UpdateDreamJob {
  title: string;
  jobDetails: string;
  skills: string[];
}
