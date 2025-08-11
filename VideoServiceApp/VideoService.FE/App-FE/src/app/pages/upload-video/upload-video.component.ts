import { Component, OnInit, signal } from '@angular/core';
import { CategoryService } from '../../services/clientService/category.service';
import { Result } from '../../models/Result';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-upload-video',
  templateUrl: './upload-video.component.html',
  styleUrls: ['./upload-video.component.css']
})

export class UploadVideoComponent implements OnInit  {
  title = signal<string>('');
  description: string = '';
  selectedFile: File | null = null;
  categories: Category[] = [];
  selectedCategories: number[] = [];
  categoriesResult: Result<Category[]> = { value: [] , isSuccess: true, error: '' };
  
  ngOnInit() {
  }

  constructor(private categoryService: CategoryService) {
    categoryService.getCategories().subscribe({
      next: (data) => {
        this.categories = data.value; // Assuming data.value is an array of Category
      },
      error: (err) => console.error('Failed to fetch categories', err)
    });
  }

  onCategoryChange(id: number, checked: boolean) {
    if (checked) {
      this.selectedCategories.push(id);
    } else {
      this.selectedCategories = this.selectedCategories.filter(catId => catId !== id);
    }
  } 

   onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    } else {
      this.selectedFile = null;
    }
  }
}

