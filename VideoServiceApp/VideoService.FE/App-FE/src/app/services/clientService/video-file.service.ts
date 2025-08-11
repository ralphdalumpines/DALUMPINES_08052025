import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VideoFile } from '../../models/VideoFile';
import { Result } from '../../models/Result';

@Injectable({
  providedIn: 'root'
})

export class VideoFileService {
  private apiUrl = 'https://localhost:7266/api/video';

  constructor(private http: HttpClient) {}

  getVideoFiles(): Observable<Result<VideoFile[]>> {
    let videos = this.http.get<Result<VideoFile[]>>(`${this.apiUrl}/getvideos`);
    console.log('Fetched videos:', videos.subscribe(data => console.log(data)));
    return videos;    
  }

  getVideoFile(id: number): Observable<Result<VideoFile>> {
    return this.http.get<Result<VideoFile>>(`${this.apiUrl}/getvideo/${id}`);
  }
}
