import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VideoFile } from '../models/VideoFile';

@Injectable({
  providedIn: 'root'
})

export class VideoFileService {
  private apiUrl = '/api/video';

  constructor(private http: HttpClient) {}

  getVideoFiles(): Observable<VideoFile[]> {
    return this.http.get<VideoFile[]>(`${this.apiUrl}/getvideos`);
  }

  getVideoFile(id: number): Observable<VideoFile> {
    return this.http.get<VideoFile>(`${this.apiUrl}/getvideo/${id}`);
  }
}
