import { Component } from '@angular/core';

interface Video {
  thumbnail: string;
  title: string;
  description: string;
  categories: string[];
}

@Component({
  selector: 'app-list-videos',
  templateUrl: './list-videos.component.html',
  styleUrls: ['./list-videos.component.css']
})

export class ListVideosComponent {
  videos: Video[] = [
    {
      thumbnail: 'assets/sample1.jpg',
      title: 'Sample Video 1',
      description: 'Description for video 1',
      categories: ['Education', 'Music']
    },
    {
      thumbnail: 'assets/sample2.jpg',
      title: 'Sample Video 2',
      description: 'Description for video 2',
      categories: ['Sports']
    }
  ];
}
