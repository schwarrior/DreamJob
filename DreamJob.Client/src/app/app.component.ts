import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DreamJobService } from './services/dream-job.service';
import { DreamJob, UpdateDreamJob } from './models/dream-job.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  dreamJob: DreamJob | null = null;
  commonSkills: string[] = [];
  
  // Edit mode states
  isTitleEditMode = false;
  isSkillsEditMode = false;
  isDetailsEditMode = false;
  
  // Edit form data
  editTitle = '';
  editDetails = '';
  selectedSkills: Set<string> = new Set();
  customSkillInput = '';
  
  loading = true;
  error: string | null = null;

  constructor(private dreamJobService: DreamJobService) {}

  ngOnInit(): void {
    this.loadDreamJob();
    this.loadCommonSkills();
  }

  loadDreamJob(): void {
    this.loading = true;
    this.dreamJobService.getDreamJob(1).subscribe({
      next: (data) => {
        this.dreamJob = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load dream job';
        this.loading = false;
        console.error(err);
      }
    });
  }

  loadCommonSkills(): void {
    this.dreamJobService.getCommonSkills().subscribe({
      next: (skills) => {
        this.commonSkills = skills;
      },
      error: (err) => {
        console.error('Failed to load common skills', err);
      }
    });
  }

  // Title pane methods
  enterTitleEditMode(): void {
    if (this.dreamJob) {
      this.editTitle = this.dreamJob.title;
      this.isTitleEditMode = true;
    }
  }

  saveTitleEdit(): void {
    if (this.dreamJob && this.editTitle.trim()) {
      const update: UpdateDreamJob = {
        title: this.editTitle.trim(),
        jobDetails: this.dreamJob.jobDetails,
        skills: this.dreamJob.skills
      };
      
      this.dreamJobService.updateDreamJob(this.dreamJob.id, update).subscribe({
        next: () => {
          if (this.dreamJob) {
            this.dreamJob.title = this.editTitle.trim();
          }
          this.isTitleEditMode = false;
        },
        error: (err) => {
          this.error = 'Failed to update title';
          console.error(err);
        }
      });
    }
  }

  cancelTitleEdit(): void {
    this.isTitleEditMode = false;
    this.editTitle = '';
  }

  // Skills pane methods
  enterSkillsEditMode(): void {
    if (this.dreamJob) {
      this.selectedSkills = new Set(this.dreamJob.skills);
      this.isSkillsEditMode = true;
    }
  }

  toggleSkill(skill: string): void {
    if (this.selectedSkills.has(skill)) {
      this.selectedSkills.delete(skill);
    } else {
      this.selectedSkills.add(skill);
    }
  }

  isSkillSelected(skill: string): boolean {
    return this.selectedSkills.has(skill);
  }

  addCustomSkill(): void {
    if (this.customSkillInput.trim()) {
      this.selectedSkills.add(this.customSkillInput.trim());
      this.customSkillInput = '';
    }
  }

  removeSkill(skill: string): void {
    this.selectedSkills.delete(skill);
  }

  saveSkillsEdit(): void {
    if (this.dreamJob && this.selectedSkills.size > 0) {
      const update: UpdateDreamJob = {
        title: this.dreamJob.title,
        jobDetails: this.dreamJob.jobDetails,
        skills: Array.from(this.selectedSkills)
      };
      
      this.dreamJobService.updateDreamJob(this.dreamJob.id, update).subscribe({
        next: () => {
          if (this.dreamJob) {
            this.dreamJob.skills = Array.from(this.selectedSkills);
          }
          this.isSkillsEditMode = false;
        },
        error: (err) => {
          this.error = 'Failed to update skills';
          console.error(err);
        }
      });
    }
  }

  cancelSkillsEdit(): void {
    this.isSkillsEditMode = false;
    this.selectedSkills.clear();
    this.customSkillInput = '';
  }

  // Details pane methods
  enterDetailsEditMode(): void {
    if (this.dreamJob) {
      this.editDetails = this.dreamJob.jobDetails;
      this.isDetailsEditMode = true;
    }
  }

  saveDetailsEdit(): void {
    if (this.dreamJob && this.editDetails.trim()) {
      const update: UpdateDreamJob = {
        title: this.dreamJob.title,
        jobDetails: this.editDetails.trim(),
        skills: this.dreamJob.skills
      };
      
      this.dreamJobService.updateDreamJob(this.dreamJob.id, update).subscribe({
        next: () => {
          if (this.dreamJob) {
            this.dreamJob.jobDetails = this.editDetails.trim();
          }
          this.isDetailsEditMode = false;
        },
        error: (err) => {
          this.error = 'Failed to update details';
          console.error(err);
        }
      });
    }
  }

  cancelDetailsEdit(): void {
    this.isDetailsEditMode = false;
    this.editDetails = '';
  }
}
