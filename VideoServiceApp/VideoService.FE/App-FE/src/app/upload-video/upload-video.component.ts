import { Component } from '@angular/core';

@Component({
  selector: 'app-upload-video',
  templateUrl: './upload-video.component.html',
  styleUrls: ['./upload-video.component.css']
})
export class UploadVideoComponent {
  categories = ['Education', 'Entertainment', 'Sports', 'Music', 'News'];
  title = '';
  description = '';
  category = '';
}
