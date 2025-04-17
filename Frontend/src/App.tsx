import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Plus } from "lucide-react";
import { Box, Button, Container, Flex, Grid, Heading, Text } from "@chakra-ui/react";
import { AppDispatch, RootState } from "./store/store";
import { fetchProjects } from "./store/projectsSlice";
import { ProjectsList } from "./components/ProjectsList";
import { ProjectForm } from "./components/ProjectForm";
import { ProjectDetails } from "./components/ProjectDetails";

function App() {
  const dispatch = useDispatch<AppDispatch>();
  const { projects, selectedProject, loading, error } = useSelector(
    (state: RootState) => state.projects
  );
  const [showNewProjectForm, setShowNewProjectForm] = useState(false);

  useEffect(() => {
    dispatch(fetchProjects());
  }, [dispatch]);

  if (loading) {
    return (
      <Flex minH="100vh" align="center" justify="center">
        <Box />
      </Flex>
    );
  }

  if (error) {
    return (
      <Flex minH="100vh" align="center" justify="center">
        <Text color="red.500">{error}</Text>
      </Flex>
    );
  }

  return (
    <Container maxW="container.xl" py={8}>
     

      <Flex justify="space-between" align="center" mb={8}>
        <Heading size="xl">Projects</Heading>
        <Button
          leftIcon={<Plus size={18} />}
          onClick={() => setShowNewProjectForm(true)}
        >
          New Project
        </Button>
      </Flex>

      {showNewProjectForm && (
        <ProjectForm onCancel={() => setShowNewProjectForm(false)} />
      )}

      <Grid
        templateColumns="1fr 3fr"
        gap={4}
      >
        <ProjectsList
          projects={projects}
          selectedProjectId={selectedProject ?? undefined}
        />
        <ProjectDetails
          project={selectedProject ? projects.find((p) => p.id === selectedProject)! : null}
        />
      </Grid>
    </Container>
  );
}

export default App;
