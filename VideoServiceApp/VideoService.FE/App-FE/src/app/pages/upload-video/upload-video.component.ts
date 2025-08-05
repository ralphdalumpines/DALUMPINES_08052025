import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Category {
  id: number;
  name: string;
}

@Component({
  selector: 'app-upload-video',
  templateUrl: './upload-video.component.html',
  styleUrls: ['./upload-video.component.css']
})

export class UploadVideoComponent implements OnInit {
  title = signal<string>('');
  description: string = '';
  selectedFile: File | null = null;

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    } else {
      this.selectedFile = null;
    }
  }
  categories: Category[] = [];
  selectedCategories: number[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<Category[]>('/api/categories').subscribe(data => {
      this.categories = data;
    });
  }

  onCategoryChange(id: number, checked: boolean) {
    if (checked) {
      this.selectedCategories.push(id);
    } else {
      this.selectedCategories = this.selectedCategories.filter(catId => catId !== id);
    }
  }
}
