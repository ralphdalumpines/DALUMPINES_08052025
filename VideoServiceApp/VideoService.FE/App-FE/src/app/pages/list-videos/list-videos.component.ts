import { Component, signal } from '@angular/core';
import { VideoFile } from '../../models/VideoFile';
import { VideoCardComponent } from '../../video-card/video-card.component';

@Component({
  selector: 'app-list-videos',
  templateUrl: './list-videos.component.html',
  styleUrls: ['./list-videos.component.css'],
  imports: [VideoCardComponent]
})

export class ListVideosComponent {
  videos = signal<VideoFile[]>([
    {
      id: 1,
      thumbnail: 'assets/video1-thumbnail.jpg',
      title: 'Sample Video 1',
      description: 'This is a sample video description for video 1.',
      categories: ['Category1', 'Category2'],
      videoUrl: 'assets/video1.mp4'
    },
    {
      id: 2,
      thumbnail: 'assets/video2-thumbnail.jpg', 
      title: 'Sample Video 2',
      description: 'This is a sample video description for video 2.',
      categories: ['Category2', 'Category3'],
      videoUrl: 'assets/video2.mp4'
    },
    {
      id: 3,
      thumbnail: 'assets/video3-thumbnail.jpg',
      title: 'Sample Video 3',
      description: 'This is a sample video description for video 3.',
      categories: ['Category1', 'Category3'],
      videoUrl: 'assets/video3.mp4'
    },
    { 
      id: 4,
      thumbnail: 'assets/video4-thumbnail.jpg',
      title: 'Sample Video 4',
      description: 'This is a sample video description for video 4.',
      categories: ['Category1', 'Category2', 'Category3'],
      videoUrl: 'assets/video4.mp4'
    } 
  ]);
}
