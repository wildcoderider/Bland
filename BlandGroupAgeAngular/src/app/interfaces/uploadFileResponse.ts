export interface UploadFileResponse {
    id: number; 
    name?: string;
    size: number;
    contentType?: string;
    extension?: string;
    timestampProcessed?: string;
    filePath?: string;
}