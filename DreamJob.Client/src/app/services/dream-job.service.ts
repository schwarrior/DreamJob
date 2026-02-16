import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DreamJob, CreateDreamJob, UpdateDreamJob } from '../models/dream-job.model';

@Injectable({
  providedIn: 'root'
})
export class DreamJobService {
  private apiUrl = '/api/dreamjobs';

  constructor(private http: HttpClient) { }

  getDreamJobs(): Observable<DreamJob[]> {
    return this.http.get<DreamJob[]>(this.apiUrl);
  }

  getDreamJob(id: number): Observable<DreamJob> {
    return this.http.get<DreamJob>(`${this.apiUrl}/${id}`);
  }

  createDreamJob(dreamJob: CreateDreamJob): Observable<DreamJob> {
    return this.http.post<DreamJob>(this.apiUrl, dreamJob);
  }

  updateDreamJob(id: number, dreamJob: UpdateDreamJob): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, dreamJob);
  }

  deleteDreamJob(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getCommonSkills(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/common-skills`);
  }
}
