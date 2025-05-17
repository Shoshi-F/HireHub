import { useForm } from 'react-hook-form';
import { TextField, Button, Container, Typography, Box } from '@mui/material';
import { Job, JobPostModel } from '../models/JobTypes';
import validationRules from '../validations/jobvalidation';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../redux/store';
import { editJob } from '../redux/slices/jobSlice';
import swal from 'sweetalert2';
import { useNavigate, useParams } from 'react-router';

const EditJob = () => {

    const id = parseInt(useParams().id || '0', 10);

    const initialState = useSelector((state: RootState) =>
        state.job.jobs.find((job: Job) => job.id === id)
    );
    const { register, handleSubmit, formState: { errors } } = useForm<JobPostModel>({
        defaultValues: initialState || {}
    });

    const dispatch: AppDispatch = useDispatch();
    const navigate = useNavigate();

    const onSubmit = async (data: JobPostModel)  => {
        console.log(data);
        try {
            var response = await dispatch(editJob({ "jobId": id, "jobData": data }));
            console.log("Updating Successful", response);
            swal.fire({
                title: "Job Updated successfully.",
                icon: "success",
                timer: 2000,
                showConfirmButton: false
            });
            navigate('/recruiter/job');
        } catch (error) {
            console.error('Error ', error);
            swal.fire({
                title: "Error Updating job.",
                icon: "error",
                text: "Please try again later."
            });
        }
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" component="h1" gutterBottom>
                Edit Job
            </Typography>
            <form onSubmit={handleSubmit(onSubmit)}>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Title"
                        {...register("title", validationRules.title)}
                        error={!!errors.title}
                        helperText={errors.title ? errors.title.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Description"
                        multiline
                        rows={4}
                        {...register("description", validationRules.description)}
                        error={!!errors.description}
                        helperText={errors.description ? errors.description.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Company"
                        {...register("company", validationRules.company)}
                        error={!!errors.company}
                        helperText={errors.company ? errors.company.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Requirements"
                        {...register("jobrequirements", validationRules.requirements)}
                        error={!!errors.jobrequirements}
                        helperText={errors.jobrequirements ? errors.jobrequirements.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Skills"
                        {...register("jobskills", validationRules.skills)}
                        error={!!errors.jobskills}
                        helperText={errors.jobskills ? errors.jobskills.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Years of Experience Required"
                        type="number"
                        {...register("yearsOfExperienceRequired", validationRules.yearsOfExperienceRequired)}
                        error={!!errors.yearsOfExperienceRequired}
                        helperText={errors.yearsOfExperienceRequired ? errors.yearsOfExperienceRequired.message : ""}
                    />
                </Box>
                <Box mb={2}>
                    <TextField
                        fullWidth
                        label="Location"
                        {...register("area", validationRules.location)}
                        error={!!errors.area}
                        helperText={errors.area ? errors.area.message : ""}
                    />
                </Box>
                <Button type="submit" variant="contained" color="primary" fullWidth>
                    Submit
                </Button>
            </form>
        </Container>
    );
};

export default EditJob;
