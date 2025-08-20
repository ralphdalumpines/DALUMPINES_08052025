import { Category } from "./Category";
import { Thumbnail } from "./Thumbnail";

export interface VideoFile {
  id: number;
  thumbnail?: Thumbnail | null;
  title: string;
  description: string;
  categories: Category[];
  path: string;
}