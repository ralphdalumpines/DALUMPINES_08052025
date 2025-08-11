import { Injectable } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})

export class UploadVideoValidatorService {

  constructor(private fb: FormBuilder) {}

  createUploadForm(): FormGroup {
    
    return this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(160)]],
      video: [null, Validators.required],
      description: ['', [Validators.required, Validators.maxLength(160)]],
      categories: [[]] // assuming this will be populated dynamically
    });
  }

  getTitleError(control: AbstractControl): string | null {

    if (control.hasError('required')) return 'Title is required.';
    if (control.hasError('maxlength')) return 'Title must be at most 160 characters.';
    return null;
  }

  getDescriptionError(control: AbstractControl): string | null {

    if (control.hasError('required')) return 'Description is required.';
    if (control.hasError('maxlength')) return 'Description must be at most 160 characters.';
    return null;
  }
}
