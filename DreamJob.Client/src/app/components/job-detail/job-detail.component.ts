import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { JobService } from '../../services/job.service';
import { ApplicationService } from '../../services/application.service';
import { Job, Application } from '../../models/models';

@Component({
  selector: 'app-job-detail',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './job-detail.component.html',
  styleUrl: './job-detail.component.css'
})
export class JobDetailComponent implements OnInit {
  job: Job | null = null;
  loading = true;
  error: string | null = null;
  showApplicationForm = false;
  
  application: Application = {
    jobId: 0,
    applicantName: '',
    applicantEmail: '',
    coverLetter: '',
    appliedDate: new Date(),
    status: 'Submitted'
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private jobService: JobService,
    private applicationService: ApplicationService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.loadJob(id);
    }
  }

  loadJob(id: number): void {
    this.loading = true;
    this.jobService.getJob(id).subscribe({
      next: (job) => {
        this.job = job;
        this.application.jobId = job.id!;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading job:', error);
        this.error = 'Failed to load job details.';
        this.loading = false;
      }
    });
  }

  toggleApplicationForm(): void {
    this.showApplicationForm = !this.showApplicationForm;
  }

  submitApplication(): void {
    if (!this.application.applicantName || !this.application.applicantEmail) {
      alert('Please fill in all required fields');
      return;
    }

    this.applicationService.createApplication(this.application).subscribe({
      next: (response) => {
        alert('Application submitted successfully!');
        this.showApplicationForm = false;
        this.resetForm();
      },
      error: (error) => {
        console.error('Error submitting application:', error);
        alert('Failed to submit application. Please try again.');
      }
    });
  }

  resetForm(): void {
    this.application = {
      jobId: this.job?.id || 0,
      applicantName: '',
      applicantEmail: '',
      coverLetter: '',
      appliedDate: new Date(),
      status: 'Submitted'
    };
  }
}
