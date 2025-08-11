import { Category } from "./Category";
import { Thumbnail } from "./Thumbnail";

export interface VideoFile {
  id: number;
  thumbnail: Thumbnail;
  title: string;
  description: string;
  categories: Category[];
  videoUrl: string;
}