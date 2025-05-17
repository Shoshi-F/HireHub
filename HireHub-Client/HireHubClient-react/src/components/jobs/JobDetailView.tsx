import React from 'react';
import { useParams } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { RootState } from '../redux/store'; // Adjust the path to your store file
import { Box, Typography, Button, Card, CardContent } from '@mui/material';

const JobDetailView = () => {
    const { id } = useParams<{ id: string }>(); // Get the job id from the URL
    const job = useSelector((state: RootState) => state.job.jobs.find((job) => job.id === Number(id))); // Convert id to number if necessary

    if (!job) return <Typography variant="h6">Job not found</Typography>;

    return (
        <Card>
            <CardContent>
                <Typography variant="h4">{job.title}</Typography>
                <Typography variant="body2">{job.description}</Typography>
            </CardContent>
            <Box p={2}>
                <Button variant="contained">Apply</Button>
            </Box>
        </Card>
    );
};

export default JobDetailView;
