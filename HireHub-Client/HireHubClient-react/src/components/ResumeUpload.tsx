import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { uploadResume } from '../redux/slices/resumeSlice';
import swal from 'sweetalert2';

const ResumeUpload = () => {
    const dispatch = useDispatch();
    const [file, setFile] = useState<File | null>(null);

    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files && event.target.files.length > 0) {
            setFile(event.target.files[0]);
        }
    };

    const handleUpload = () => {
        if (!file) {
            swal.fire('Please select a file to upload');
            return;
        }

        dispatch(uploadResume({ file }));
    };

    return (
        <div>
            <input type="file" onChange={handleFileChange} />
            <button onClick={handleUpload}>Upload Resume</button>
        </div>
    );
};

export default ResumeUpload;
