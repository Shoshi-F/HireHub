import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { generateUploadUrl, uploadFileToPresignedUrl, confirmUpload } from '../../services/ResumeService';

// שינוי שם הפונקציה ל-uploadResume
export const uploadResume = createAsyncThunk(
    'resume/uploadResume',
    async ({ file }: { file: File }, { rejectWithValue }) => {
        try {
            const presignedUrl = await generateUploadUrl(file.type);
            await uploadFileToPresignedUrl(presignedUrl, file);
            const result = await confirmUpload(file.type);
            return result;
        } catch (error) {
            if (error instanceof Error && 'response' in error) {
                return rejectWithValue((error as any).response?.data || 'Upload failed');
            }
            return rejectWithValue('Upload failed');
        }
    }
);

const resumeSlice = createSlice({
    name: 'resume',
    initialState: {
        uploadStatus: 'idle',
        error: null as string | null,
    },
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(uploadResume.pending, (state) => {
                state.uploadStatus = 'loading';
                state.error = null;
            })
            .addCase(uploadResume.fulfilled, (state) => {
                state.uploadStatus = 'succeeded';
            })
            .addCase(uploadResume.rejected, (state, action) => {
                state.uploadStatus = 'failed';
                state.error = action.payload as string;
            });
    },
});

export default resumeSlice.reducer;
